import s from './LoginPage.module.css';
import { FormInput, PasswordInput } from '../../components/FormInput/FormInput';
import { Link } from 'react-router-dom';

const LoginPage = () => {
    return (
        <div className={s.page_container}>
            <form className={`flex ${s.form}`} action='#'>
                <img className={s.logo} src='/udv-logo.svg' alt='' />
                <h2 className={s.title}>Вход</h2>
               
                <div className={`flex ${s.input_container}`}>
                    <FormInput type='email' id='email' placeholder='ivanovivan@udv.group'>
                        Почта в домене udv.group
                    </FormInput>
                    <PasswordInput id='password'>Пароль</PasswordInput>
                </div>

                <p className={s.p}>
                    Нет аккаунта?&nbsp;
                    <Link className={s.link} to='/register'>
                        Зарегистрироваться
                    </Link>
                </p>
                <a className={s.link} href='#'>
                    Не помните пароль?
                </a>
                <button className={s.login_button}>Войти</button>
            </form>
        </div>
    );
};

export default LoginPage;
