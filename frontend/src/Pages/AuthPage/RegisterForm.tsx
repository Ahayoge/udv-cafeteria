import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { Formik, Form, useField } from 'formik';
import s from './AuthPage.module.css';

const RegisterForm = ({ changeForm }: any) => {
    type Props = {
        label: string;
        name: string;
        id: string;
        type?: string;
        placeholder?: string;
        children?: React.ReactNode;
    };

    type User = {
        roles: string;
        firstName: string;
        patronymic: string;
        lastName: string;
        email: string;
        phone: string;
        password: string;
        passwordConfirm: string;
        birthDate: string;
        company: string;
        position: string;
        department: string;
    };

    const navigate = useNavigate();
    // Декодируем JWT-токен, полученный с сервера
    const getUserRoles = (token: string) => {
        const data = JSON.parse(atob(token.split('.')[1]));
        const roles = data['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        return roles;
    };

    const formatDate = (date: string) => {
        const newDate = date.split('-');
        return `${newDate[2]}.${newDate[1]}.${newDate[0]}`;
    };

    const Register: any = (values: User) => {
        axios
            .post('auth/register', {
                roles: values.roles == 'Admin' ? ['Worker', 'Admin'] : ['Worker'],
                firstName: values.firstName,
                patronymic: values.patronymic,
                lastName: values.lastName,
                email: values.email,
                phone: values.phone,
                password: values.password,
                birthDate: formatDate(values.birthDate),
                company: values.company,
                position: values.position,
                department: values.department,
            })
            .then(function (response) {
                if (response.status === 201) {
                    localStorage.setItem('authToken', response.data.accessToken);
                    const roles = getUserRoles(response.data.accessToken);
                    localStorage.setItem('roles', roles);
                    navigate('/benefits/all');
                }
            })
            .catch(function (error) {
                console.log(error.response.data.error);
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

    const MySelectInput = ({ label, children, ...props }: Props) => {
        const [field, meta] = useField(props);
        return (
            <div className={`flex ${s.input_wrap}`}>
                <label className={s.label} htmlFor={props.id || props.name}>
                    {label}
                </label>
                <select className={s.input} {...field} {...props}>
                    {children}
                </select>
                {meta.touched && meta.error ? <p className={s.error}>{meta.error}</p> : null}
            </div>
        );
    };

    return (
        <Formik
            validateOnChange={false}
            validateOnBlur={false}
            initialValues={{
                roles: 'admin',
                firstName: '',
                patronymic: '',
                lastName: '',
                email: '',
                phone: '',
                password: '',
                passwordConfirm: '',
                birthDate: '',
                company: 'Udv',
                position: 'Programmer',
                department: 'Development',
            }}
            validate={(values: User) => {
                const errors: Partial<User> = {};
                if (!values.email) {
                    errors.email = 'Введите Email';
                } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)) {
                    errors.email = 'Email указан неверно';
                }
                if (!values.firstName) {
                    errors.firstName = 'Введите имя';
                }
                if (values.password != values.passwordConfirm || !values.passwordConfirm) {
                    errors.passwordConfirm = 'Пароли не совпадают';
                }
                return errors;
            }}
            onSubmit={(values, { setSubmitting }) => {
                Register(values);
                setSubmitting(false);
                console.log(values);
            }}>
            {({ isSubmitting }) => (
                <Form className={`flex ${s.register_form}`}>
                    <div className={`flex ${s.wrap}`}>
                        <MyTextInput
                            label='Фамилия'
                            name='lastName'
                            id='lastName'
                            type='text'
                            placeholder='Иванов'
                        />
                        <MyTextInput
                            label='Имя'
                            name='firstName'
                            id='firstName'
                            type='text'
                            placeholder='Иван'
                        />
                        <MyTextInput
                            label='Отчество'
                            name='patronymic'
                            id='patronymic'
                            type='text'
                            placeholder='Иванович'
                        />
                        <MyTextInput
                            label='Дата рождения'
                            name='birthDate'
                            id='birthDate'
                            type='date'
                        />
                        <MyTextInput
                            label='Номер телефона'
                            name='phone'
                            id='phone'
                            type='tel'
                            placeholder='+79000000000'
                        />
                        <MyTextInput
                            label='Почта в домене udv.group'
                            name='email'
                            id='email'
                            type='email'
                            placeholder='ivanovivan@udv.group'
                        />
                        <MySelectInput label='Юр.лицо' name='company' id='company'>
                            <option className={s.option} value='Udv'>
                                UDV
                            </option>
                            <option className={s.option} value='FtSoft'>
                                FT-SOFT
                            </option>
                        </MySelectInput>
                        <MySelectInput label='Должность' name='position' id='position'>
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
                        </MySelectInput>
                        <MySelectInput label='Подразделение' name='department' id='department'>
                            <option className={s.option} value='Development'>
                                Разработка
                            </option>
                            <option className={s.option} value='Testing'>
                                Тестирование
                            </option>
                        </MySelectInput>

                        <MySelectInput label='Роль' name='roles' id='roles'>
                            <option className={s.option} value='Worker'>
                                Сотрудник
                            </option>
                            <option className={s.option} value='Admin'>
                                HR
                            </option>
                        </MySelectInput>
                        <MyTextInput label='Пароль' name='password' type='password' id='password' />
                        <MyTextInput
                            label='Подтверждение пароля'
                            name='passwordConfirm'
                            type='password'
                            id='passwordConfirm'
                        />
                    </div>
                    <p className={s.hint}>
                        Уже есть аккаунт? <span onClick={changeForm}>Войти</span>
                    </p>
                    <button className={s.button} type='submit' disabled={isSubmitting}>
                        Регистрация
                    </button>
                </Form>
            )}
        </Formik>
    );
};

export default RegisterForm;
