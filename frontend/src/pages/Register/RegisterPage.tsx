import s from './RegisterPage.module.css';
import {FormInput, PasswordInput} from '../../components/FormInput/FormInput';
import { Link } from 'react-router-dom';

const RegisterPage = () => {
    return (
        <div className={s.page_container}>
            <form className={`flex ${s.form}`} action='#'>
                <img className={s.logo} src='/udv-logo.svg' alt='' />
                <h2 className={s.title}>Регистрация</h2>
                <div className={`flex ${s.input_container}`}>
                    <FormInput type='text' id='name' placeholder='Иванов Иван Иванович'>
                        ФИО
                    </FormInput>
                    <FormInput type='date' id='birthday'>
                        Дата рождения
                    </FormInput>
                    <FormInput type='email' id='email' placeholder='ivanovivan@udv.group'>
                        Почта в домене udv.group
                    </FormInput>
                    <FormInput
                        type='tel'
                        id='tel'
                        pattern='7[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}'
                        placeholder='79000000000'>
                        Номер телефона
                    </FormInput>
                    <PasswordInput id='password'>Пароль</PasswordInput>
                    <FormInput type='text' id='company'>
                        Юр. лицо
                    </FormInput>
                    <FormInput type='text' id='position'>
                        Должность
                    </FormInput>
                    <FormInput type='text' id='department'>
                        Подразделение
                    </FormInput>
                </div>
                <p className={s.p}>
                    Уже есть аккаунт?&nbsp;
                    <Link className={s.link} to='/login'>
                        Войти
                    </Link>
                </p>
                <button className={s.login_button}>Зарегистрироваться</button>
            </form>
        </div>
    );
};

export default RegisterPage;
