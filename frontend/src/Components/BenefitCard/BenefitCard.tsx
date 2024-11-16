import { Link } from 'react-router-dom';
import s from './BenefitCard.module.css';

type Props = {
    id: string
    name: string;
    conditions: {
        experienceYearsRequired?: number;
        ucoinPrice?: number;
        isFormRequired: boolean;
    };
};

const BenefitCard = (props: Props) => {
    const {name,conditions, id} = props;
    const {experienceYearsRequired, ucoinPrice, isFormRequired} = conditions;
    return (
        <li className={`flex ${s.card}`}>
            <div className={s.background}>
                <img className={s.background_img} src="/cat.jpg" alt="Котик :3" loading='lazy'/>
            </div>
            <div className={`flex ${s.info}`}>
                <h2 className={s.title}>{name}</h2>
                <p className={`flex ${s.description}`}>
                    Условие:
                    {experienceYearsRequired && <span>Стаж: {experienceYearsRequired} год</span>}
                    {ucoinPrice && <span>Стоимость: {ucoinPrice} u-coins</span>}
                    {isFormRequired && <span>Необходимо заполнить анкету</span>}
                </p>
                <Link to={`/benefits/${id}`} className={`flex ${s.button}`}>Узнать больше</Link>
            </div>
        </li>
    );
};

export default BenefitCard;
