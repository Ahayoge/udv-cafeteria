import { useEffect, useState } from 'react';
import s from './SingleBenefitPage.module.css';
import axios, { AxiosResponse } from 'axios';
import { useParams } from 'react-router-dom';

const SingleBenefitPage = () => {
    type BenefitData = {
        id: string;
        name: string;
        description: string;
        validityPeriodDays: number;
        additionalInfo: string;
        conditions: {
            experienceYearsRequired?: number;
            ucoinPrice?: number;
            isFormRequired: boolean;
        };
    };

    const { id } = useParams();
    const [benefitData, setBenefitData] = useState<BenefitData>();
    const getBenefitData = () => {
        let token = localStorage.getItem('authToken');
        axios
            .get(`http://95.82.231.190:7178/api/benefits/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response: AxiosResponse) => {
                setBenefitData(response.data);
            });
    };

    const requestBenefit = () => {
        let token = localStorage.getItem('authToken');
        axios.post(`http://95.82.231.190:7178/api/benefits/${id}/apply`, null, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
    };

    useEffect(() => {
        getBenefitData();
    }, []);
    return (
        <div className={s.container}>
            <div className={`flex ${s.benefit_container}`}>
                <img className={s.img} src='/benefit-img.png' alt='#' />
                <div className={`flex ${s.benefit_info}`}>
                    <h2 className={s.title}>{benefitData?.name}</h2>
                    <p className={s.description}>{benefitData?.description}</p>

                    <table className={s.table}>
                        <tbody className={`flex ${s.tbody}`}>
                            {benefitData?.validityPeriodDays && (
                                <tr className={`flex ${s.tr}`}>
                                    <th className={s.th}>Срок действия:</th>
                                    <td>{benefitData?.validityPeriodDays} дней</td>
                                </tr>
                            )}
                            <tr className={`flex ${s.tr}`}>
                                <th className={s.th}>Условия:</th>
                                <td>
                                    {benefitData?.conditions.ucoinPrice && (
                                        <p>{benefitData?.conditions.ucoinPrice} u-coins</p>
                                    )}
                                    {benefitData?.conditions.experienceYearsRequired && (
                                        <p>
                                            Стаж {benefitData?.conditions.experienceYearsRequired}{' '}
                                            лет
                                        </p>
                                    )}
                                </td>
                            </tr>

                            <tr className={`flex ${s.tr}`}>
                                <th className={s.th}>Примечания:</th>
                                <td>
                                    {benefitData?.additionalInfo
                                        ? benefitData?.additionalInfo
                                        : 'Данная льгота не требует дополнительных условий'}
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <button className={s.button} onClick={requestBenefit}>
                        Подать заявку
                    </button>
                </div>
            </div>
        </div>
    );
};

export default SingleBenefitPage;
