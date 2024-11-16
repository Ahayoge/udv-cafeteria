import { useEffect, useState } from 'react';
import s from './BenefitsPage.module.css';
import axios, { AxiosResponse } from 'axios';
import BenefitCard from '../../Components/BenefitCard/BenefitCard';
import { useNavigate, Link } from 'react-router-dom';
import SimpleBar from 'simplebar-react';
import 'simplebar-react/dist/simplebar.min.css';
import './scrollbar.css'

type BenefitCard = {
    id: string;
    name: string;
    conditions: {
        experienceYearsRequired?: number;
        ucoinPrice?: number;
        isFormRequired: boolean;
    };
};

const BenefitsPage = () => {
    const [benefitsList, setBenefitsList] = useState<BenefitCard[]>([]);
    const navigate = useNavigate();
    const GetBenefits = () => {
        let token = localStorage.getItem('authToken');
        axios
            .get('http://95.82.231.190:7178/api/benefits', {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response: AxiosResponse) => {
                setBenefitsList(response.data);
            })
            .catch(error => {
                if (error.status === 401) {
                    navigate('/auth');
                }
            });
    };

    const CardsList = () => {
        return (
            <div className={s.list_wrap}>
                <SimpleBar style={{ maxHeight: 540 }} autoHide={false}>
                    <ul className={s.list}>
                        {benefitsList.map((item: BenefitCard) => {
                            return (
                                <BenefitCard
                                    key={benefitsList.indexOf(item)}
                                    name={item.name}
                                    conditions={item.conditions}
                                    id={item.id}
                                />
                            );
                        })}
                    </ul>
                </SimpleBar>
            </div>
        );
    };

    useEffect(() => {
        GetBenefits();
    }, []);

    return (
        <div className={s.container}>
            <aside className={s.aside}>
                <div className={s.admin_mode}>
                    <p className={s.admin_mode_text}>Режим администратора</p>
                </div>
                <div className={`flex ${s.filters}`}>
                    <h3 className={s.filters_title}>Выберите категорию:</h3>

                    <label className={`flex ${s.filters_label}`} htmlFor='education'>
                        <input className={s.checkbox} type='checkbox' name='' id='education' />
                        Образование
                    </label>

                    <label className={`flex ${s.filters_label}`} htmlFor='medic'>
                        <input className={s.checkbox} type='checkbox' name='' id='medic' />
                        ДМС
                    </label>

                    <label className={`flex ${s.filters_label}`} htmlFor='sport'>
                        <input className={s.checkbox} type='checkbox' name='' id='sport' />
                        Спорт
                    </label>

                    <label className={`flex ${s.filters_label}`} htmlFor='fun'>
                        <input className={s.checkbox} type='checkbox' name='' id='fun' />
                        Досуг
                    </label>
                </div>
            </aside>

            <main className={s.main}>
                <input className={s.search_input} type='text' placeholder='Поиск' />
                <Link to={'/benefits/new'} className={`flex ${s.benefit_button}`}>
                    Добавить льготу
                </Link>

                <CardsList />
            </main>
        </div>
    );
};

export default BenefitsPage;
