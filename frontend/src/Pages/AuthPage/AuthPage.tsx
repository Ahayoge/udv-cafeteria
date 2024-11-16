import { useState } from 'react';
import clsx from 'clsx';
import s from './AuthPage.module.css';
import LoginForm from './LoginForm';
import RegisterForm from './RegisterForm';

const AuthPage = () => {
    const [isLoginPage, setLoginPage] = useState<boolean>(false);

    const handlePageSwitch = () => {
        setLoginPage(!isLoginPage);
    };

    return (
        <div className={clsx('flex', s.background, isLoginPage ? s.img_login : s.img_register)}>
            <div className={clsx('flex', s.form_container)}>
                <img className={s.logo} src='udv-logo.svg' alt='Логотип UDV Group' />
                {!isLoginPage ? (
                    <LoginForm changeForm={handlePageSwitch} />
                ) : (
                    <RegisterForm changeForm={handlePageSwitch} />
                )}
            </div>
        </div>
    );
};
export default AuthPage;
