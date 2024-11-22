import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { Formik, Form, useField } from 'formik';
import s from './AuthPage.module.css';
import { useToast } from '../../Store/ToastContext';
import 'react-toastify/dist/ReactToastify.css';

const NewLoginForm = ({ changeForm }: any) => {
    const aboba = useToast();
    const { notify } = useToast(); // получаем notify из контекста
    type Props = {
        label: string;
        name: string;
        type: string;
        id: string;
        placeholder?: string;
    };

    type User = {
        email: string;
        password: string;
    };

    const navigate = useNavigate();
    // Декодируем JWT-токен, полученный с сервера
    const getUserRoles = (token: string) => {
        const data = JSON.parse(atob(token.split('.')[1]));
        const roles = data['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        return roles;
    };

    // Функция входа на сайт. Отправляем запрос на сервер, после чего
    // либо записываем токен в localStorage, либо выводим в консоль ошибку
    const Login: any = (email: string, password: string) => {
        axios
            .post('auth/login', {
                email: email,
                password: password,
            })
            .then(response => {
                if (response.status === 200) {
                    localStorage.setItem('authToken', response.data.accessToken);
                    const roles = getUserRoles(response.data.accessToken);
                    localStorage.setItem('roles', roles);
                    notify('Успешная авторизация', 'success', {
                        position: 'bottom-right',
                        onClose() {
                            navigate('/benefits/all');
                        },
                    });
                }
            })
            .catch(error => {
                notify(error.response.data.error, 'error', { position: 'bottom-right' });
            });
    };

    const MyTextInput = ({ label, ...props }: Props) => {
        const [field, meta] = useField(props);
        return (
            <div className={`flex ${s.input_wrap}`}>
                <label className={s.label} htmlFor={props.id || props.name}>
                    {label}
                </label>
                <input className={s.input} {...field} {...props} />
                {meta.touched && meta.error ? <p className={s.error}>{meta.error}</p> : null}
            </div>
        );
    };

    return (
        <Formik
            validateOnChange={false}
            validateOnBlur={false}
            initialValues={{ email: '', password: '' }}
            validate={(values: User) => {
                const errors: Partial<User> = {};
                if (!values.email) {
                    errors.email = 'Введите Email';
                } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)) {
                    errors.email = 'Email указан неверно';
                }
                if (!values.password) {
                    errors.password = 'Введите пароль';
                }
                return errors;
            }}
            onSubmit={(values, { setSubmitting }) => {
                Login(values.email, values.password);
                setSubmitting(false);
            }}>
            {({ isSubmitting }) => (
                <Form className={`flex ${s.login_form}`}>
                    <MyTextInput
                        label='Почта в домене udv.group'
                        name='email'
                        type='email'
                        id='email'
                        placeholder='ivanovivan@udv.group'
                    />
                    <MyTextInput label='Пароль' name='password' type='password' id='password' />
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
                    <button className={s.button} type='submit' disabled={isSubmitting}>
                        Войти
                    </button>
                    <button
                        onClick={() => {
                            console.log(aboba.notify);
                        }}
                        type='button'>
                        Проверка
                    </button>
                </Form>
            )}
        </Formik>
    );
};

export default NewLoginForm;
