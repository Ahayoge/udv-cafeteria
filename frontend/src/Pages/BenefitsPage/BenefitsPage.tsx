// Libs
import { useEffect, useState } from 'react';
import axios, { AxiosResponse } from 'axios';
import { useNavigate, Link } from 'react-router-dom';
import { OverlayScrollbarsComponent } from 'overlayscrollbars-react';
import 'overlayscrollbars/overlayscrollbars.css';
import s from './BenefitsPage.module.css';
import BenefitCard from '../../Components/BenefitCard/BenefitCard';

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
            .get('benefits', {
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
            <OverlayScrollbarsComponent
                className={s.list_wrap}
                element='div'
                options={{
                    scrollbars: { theme: 'os-theme-light', autoHide: 'leave', autoHideDelay: 100 },
                }}>
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
            </OverlayScrollbarsComponent>
        );
    };

    useEffect(() => {
        GetBenefits();
    }, []);

    return (
        <div className={`flex ${s.grid}`}>
            <div className={`flex ${s.top}`}>
                <div className={s.admin_mode}>
                    <p className={s.admin_mode_text}>Режим администратора</p>
                </div>
                <input className={s.search_input} type='text' placeholder='Поиск' />
                {localStorage.getItem('roles') == 'Worker,Admin' && (
                    <Link to={'/benefits/new'} className={`flex ${s.benefit_button}`}>
                        Добавить льготу
                    </Link>
                )}
            </div>

            <main className={`flex ${s.benefits}`}>
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
                <CardsList />
            </main>
        </div>
    );
};

export default BenefitsPage;
