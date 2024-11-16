import s from './AuthPage.module.css';
import { useState } from 'react';
import axios from 'axios';
import { sha256 } from 'js-sha256';

const RegisterForm = ({ changeForm }: any) => {
    const defaultValues = {
        roles: '',
        firstName: '',
        patronymic: '',
        lastName: '',
        email: '',
        phone: '',
        password: '',
        birthDate: '',
        company: 'Udv',
        position: 'Programmer',
        department: 'Development',
    };

    const [inputs, setInputs] = useState(defaultValues);
    const handleInputs = (
        e: React.ChangeEvent<HTMLInputElement> | React.ChangeEvent<HTMLSelectElement>
    ) => {
        setInputs(prevState => ({ ...prevState, [e.target.name]: e.target.value }));
        console.log(inputs);
    };
    const formatBirthDate = () => {
        const birthDate = inputs.birthDate.split('-');
        return `${birthDate[2]}.${birthDate[1]}.${birthDate[0]}`;
    };

    const register: any = () => {
        const hashedPassword = sha256(inputs.password);
        const newDate = formatBirthDate();
        axios
            .post('http://95.82.231.190:7178/api/auth/register', {
                roles: inputs.roles == 'Worker' ? ['Worker'] : ['Worker', 'Admin'],
                firstName: inputs.firstName,
                patronymic: inputs.patronymic,
                lastName: inputs.lastName,
                email: inputs.email,
                phone: inputs.phone,
                password: hashedPassword,
                birthDate: newDate,
                company: inputs.company,
                position: inputs.position,
                department: inputs.department,
            })
            .then(function (response) {
                if (response.status == 201) alert('Успешная регистрация');
            })
            .catch(function (error) {
                console.log(error);
            });
    };

    return (
        <form className={`flex ${s.register_form}`} method='post'>
            <div className={s.container}>
                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='lastName'>
                        Фамилия
                    </label>
                    <input
                        className={s.input}
                        id='lastName'
                        name='lastName'
                        type='text'
                        placeholder='Иванов'
                        onChange={handleInputs}
                        value={inputs.lastName}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='firstName'>
                        Имя
                    </label>
                    <input
                        className={s.input}
                        id='firstName'
                        name='firstName'
                        type='text'
                        placeholder='Иван'
                        onChange={handleInputs}
                        value={inputs.firstName}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='patronymic'>
                        Отчество
                    </label>
                    <input
                        className={s.input}
                        id='patronymic'
                        name='patronymic'
                        type='text'
                        placeholder='Иванович'
                        onChange={handleInputs}
                        value={inputs.patronymic}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='roles'>
                        Роль
                    </label>
                    <select className={s.input} name='roles' id='roles' onChange={handleInputs}>
                        <option className={s.option} value='Worker'>
                            Сотрудник
                        </option>
                        <option className={s.option} value='Admin'>
                            HR
                        </option>
                    </select>
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='company'>
                        Юр.лицо
                    </label>
                    <select
                        className={s.input}
                        value={inputs.company}
                        name='company'
                        id='company'
                        onChange={handleInputs}>
                        <option className={s.option} value='Udv'>
                            UDV
                        </option>
                        <option className={s.option} value='FtSoft'>
                            FT-SOFT
                        </option>
                    </select>
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='position'>
                        Должность
                    </label>
                    <select
                        className={s.input}
                        name='position'
                        id='position'
                        value={inputs.position}
                        onChange={handleInputs}>
                        <option className={s.option} value='Programmer'>
                            Разработчик
                        </option>
                        <option className={s.option} value='Analyst'>
                            Аналитик
                        </option>
                        <option className={s.option} value='Tester'>
                            Тестировщик
                        </option>
                        <option className={s.option} value='Designer'>
                            Дизайнер
                        </option>
                        <option className={s.option} value='Teamleader'>
                            Тимлид
                        </option>
                        <option className={s.option} value='HR'>
                            HR
                        </option>
                    </select>
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='department'>
                        Подразделение
                    </label>
                    <select
                        className={s.input}
                        name='department'
                        id='department'
                        onChange={handleInputs}>
                        <option className={s.option} value='Development'>
                            Разработка
                        </option>
                        <option className={s.option} value='Testing'>
                            Тестирование
                        </option>
                    </select>
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='birthDate'>
                        День рождения
                    </label>
                    <input
                        className={s.input}
                        id='birthDate'
                        name='birthDate'
                        type='date'
                        onChange={handleInputs}
                        value={inputs.birthDate}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='email'>
                        Почта в домене udv.group
                    </label>
                    <input
                        className={s.input}
                        id='email'
                        name='email'
                        type='email'
                        placeholder='ivanovivan@udv.group'
                        onChange={handleInputs}
                        value={inputs.email}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='phone'>
                        Номер телефона
                    </label>
                    <input
                        className={s.input}
                        id='phone'
                        name='phone'
                        type='tel'
                        placeholder='+79000000000'
                        onChange={handleInputs}
                        value={inputs.phone}
                    />
                </fieldset>

                <fieldset className={`flex ${s.input_wrap}`}>
                    <label className={s.label} htmlFor='password'>
                        Пароль
                    </label>
                    <input
                        className={s.input}
                        id='password'
                        name='password'
                        type='password'
                        onChange={handleInputs}
                    />
                </fieldset>
            </div>
            <p className={s.hint}>
                Уже есть аккаунт? <span onClick={changeForm}>Войти</span>
            </p>
            <button className={s.button} type='button' onClick={register}>
                Регистрация
            </button>
        </form>
    );
};

export default RegisterForm;
