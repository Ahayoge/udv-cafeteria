import s from './AddBenefit.module.css';
import { useState } from 'react';
import axios, { AxiosResponse } from 'axios';

const AddBenefitPage = () => {
    const defaultValues = {
        name: '',
        category: '',
        description: '',
        validityPeriodDays: 0,
        realPrice: 0,
        experienceYearsRequired: 0,
        ucoinPrice: 0,
        additionalInfo: '',
        formUrl: '',
        onboardingRequired: false,
    };
    const [inputs, setInputs] = useState(defaultValues);
    const handleInputs = (
        e:
            | React.ChangeEvent<HTMLInputElement>
            | React.ChangeEvent<HTMLSelectElement>
            | React.ChangeEvent<HTMLTextAreaElement>
    ) => {
        setInputs(prevState => ({ ...prevState, [e.target.name]: e.target.value }));
        console.log(inputs);
    };

    const addBenefit = () => {
        const token = localStorage.getItem('authToken');
        console.log(token);
        axios
            .post(
                'http://95.82.231.190:7178/api/benefits',
                {
                    name: "'; DROP DATABASE ssoncho; --",
                    category: inputs.category,
                    description: inputs.description,
                    validityPeriodDays: inputs.validityPeriodDays,
                    realPrice: inputs.realPrice,
                    onboardingRequired: true,
                    additionalInfo: inputs.additionalInfo,
                },
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            )
            .then((response: AxiosResponse) => {
                console.log(response);
            })
            .catch(error => {
                console.log(error);
            });
    };

    return (
        <div className={s.container}>
            <h2 className={s.title}>Добавление льготы</h2>
            <form className={s.form} action=''>
                <div className={`flex ${s.img_picker}`}>
                    <button type='button' className={s.img_button}>
                        Добавить фото
                    </button>
                </div>
                <div className={`flex ${s.inputs_left}`}>
                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='name' className={s.label}>
                            Название
                        </label>
                        <input
                            className={s.input}
                            type='text'
                            id='name'
                            name='name'
                            onChange={handleInputs}
                            value={inputs.name}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='category' className={s.label}>
                            Категория
                        </label>
                        <input
                            className={s.input}
                            type='text'
                            id='category'
                            name='category'
                            onChange={handleInputs}
                            value={inputs.category}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='validityPeriodDays' className={s.label}>
                            Срок действия, дней
                        </label>
                        <input
                            className={s.input}
                            type='text'
                            id='validityPeriodDays'
                            name='validityPeriodDays'
                            onChange={handleInputs}
                            value={inputs.validityPeriodDays}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='description' className={s.label}>
                            Описание
                        </label>
                        <textarea
                            className={s.input}
                            name='description'
                            id='description'
                            cols={30}
                            rows={3}
                            onChange={handleInputs}
                            value={inputs.description}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='name' className={s.label}>
                            Требования к получению
                        </label>
                        <select className={s.input} name='' id=''>
                            <option className={s.option} value=''>
                                1000 u-coins
                            </option>
                            <option className={s.option} value=''>
                                2000 u-coins
                            </option>
                            <option className={s.option} value=''>
                                3000 u-coins
                            </option>
                            <option className={s.option} value=''>
                                Стаж 1 год
                            </option>
                            <option className={s.option} value=''>
                                Стаж 2 года
                            </option>
                            <option className={s.option} value=''>
                                Стаж 3 года
                            </option>
                        </select>
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <p className={s.label}>Прилагается анкета?</p>
                        <div className={`flex ${s.labels_wrap}`}>
                            <label className={`flex ${s.radio_label}`} htmlFor='formRequired'>
                                <input type='radio' name='isFormRequired' id='formRequired' />
                                Да
                            </label>
                            <label className={`flex ${s.radio_label}`} htmlFor='formNotRequired'>
                                <input type='radio' name='isFormRequired' id='formNotRequired' />
                                Нет
                            </label>
                        </div>
                    </fieldset>
                </div>
                <div className={`flex ${s.inputs_right}`}>
                    <fieldset className={`flex ${s.input_wrap}`}>
                        <p className={s.label}>Адаптационный период должен быть пройден?</p>
                        <div className={`flex ${s.labels_wrap}`}>
                            <label className={`flex ${s.radio_label}`} htmlFor='required'>
                                <input type='radio' name='onboardingRequired' id='required' />
                                Да
                            </label>
                            <label className={`flex ${s.radio_label}`} htmlFor='notRequired'>
                                <input type='radio' name='onboardingRequired' id='notRequired' />
                                Нет
                            </label>
                        </div>
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='additionalInfo' className={s.label}>
                            Примечание
                        </label>
                        <textarea
                            className={s.input}
                            name='additionalInfo'
                            id='additionalInfo'
                            cols={30}
                            rows={3}
                            value={inputs.additionalInfo}
                            onChange={handleInputs}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <label htmlFor='realPrice' className={s.label}>
                            Стоимость для компании
                        </label>
                        <input
                            className={s.input}
                            type='text'
                            id='realPrice'
                            name='realPrice'
                            value={inputs.realPrice}
                            onChange={handleInputs}
                        />
                    </fieldset>

                    <fieldset className={`flex ${s.input_wrap}`}>
                        <p className={s.label}>Льготе требуется модерация?</p>
                        <div className={`flex ${s.labels_wrap}`}>
                            <label className={`flex ${s.radio_label}`} htmlFor='required'>
                                <input type='radio' name='onboardingRequired' id='required' />
                                Да
                            </label>
                            <label className={`flex ${s.radio_label}`} htmlFor='notRequired'>
                                <input type='radio' name='onboardingRequired' id='notRequired' />
                                Нет
                            </label>
                        </div>
                    </fieldset>
                    <button className={s.button} type='button' onClick={addBenefit}>
                        Отправить заявку
                    </button>
                </div>
            </form>
        </div>
    );
};

export default AddBenefitPage;
