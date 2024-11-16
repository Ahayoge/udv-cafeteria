import axios from 'axios';
import s from './AuthPage.module.css';
import { useState } from 'react';
import { sha256 } from 'js-sha256';
import { useNavigate } from 'react-router-dom';

const LoginForm = ({ changeForm }: any) => {
    const navigate = useNavigate();
    // Дефолтные значения полей ввода
    const defaultInputValues = {
        email: '',
        password: '',
    };

    // Храним значения полей ввода
    const [inputs, setInputs] = useState(defaultInputValues);

    // Функция для управления полями ввода формы
    const handleInputs = (e: React.ChangeEvent<HTMLInputElement>) => {
        setInputs(prevState => ({ ...prevState, [e.target.name]: e.target.value }));
    };

    // Декодируем JWT-токен, полученный с сервера
    const getUserRoles = (token: string) => {
        const data = JSON.parse(atob(token.split('.')[1]));
        const roles = data['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        return roles;
    };

    // Функция входа на сайт. Отправляем запрос на сервер, после чего
    // либо записываем токен в localStorage, либо выводим в консоль ошибку
    const Login: any = () => {
        const hashedPassword = sha256(inputs.password);
        axios
            .post('http://95.82.231.190:7178/api/auth/login', {
                email: inputs.email,
                password: hashedPassword,
            })
            .then(function (response) {
                if (response.status === 200) {
                    localStorage.setItem('authToken', response.data.accessToken);
                    const roles = getUserRoles(response.data.accessToken);
                    localStorage.setItem('roles', roles);
                    navigate('/benefits/all');
                }
            })
            .catch(function (error) {
                alert(error.response.data.error);
            });
    };

    return (
        <form
            className={`flex ${s.login_form}`}
            action='http://95.82.231.190:7178/api/auth/login'
            method='post'>
            <h2 className={s.title}>Вход</h2>
            <fieldset className={`flex ${s.input_wrap}`}>
                <label htmlFor='email' className={s.label}>
                    Почта в домене udv.group
                </label>
                <input
                    className={s.input}
                    value={inputs.email}
                    onChange={e => handleInputs(e)}
                    type='email'
                    id='email'
                    name='email'
                    placeholder='ivanovivan@udv.group'
                />
            </fieldset>

            <fieldset className={`flex ${s.input_wrap}`}>
                <label htmlFor='password' className={s.label}>
                    Пароль
                </label>
                <input
                    className={s.input}
                    value={inputs.password}
                    onChange={e => handleInputs(e)}
                    type='password'
                    id='password'
                    name='password'
                />
            </fieldset>

            <p className={s.hint}>
                Нет аккаунта? <span onClick={changeForm}>Зарегистрироваться</span>
            </p>
            <p className={s.hint}>
                <span
                    onClick={() => {
                        alert('Сочувствуем! Но пока ничем помочь не можем.');
                    }}>
                    Не помните пароль?
                </span>
            </p>

            <button className={s.button} type='button' onClick={Login}>
                Войти
            </button>
        </form>
    );
};
export default LoginForm;
