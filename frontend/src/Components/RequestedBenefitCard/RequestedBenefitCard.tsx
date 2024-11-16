import s from './RequestedBenefitCard.module.css';

type Props = {
    data: { id: string; name: string; status: string; statusChangedWhen: string };
};

const RequestedBenefitCard = (props: Props) => {
    const { name, status, statusChangedWhen } = props.data;

    const formatDate = (date: string) => {
        const [year, month, day] = date.split('-');
        return `${day}.${month}.${year}`;
    };

    return (
        <li className={`flex ${s.card}`}>
            <div className={s.background}>
                <img className={s.background_img} src='/cat.jpg' alt='' />
            </div>
            <div className={`flex ${s.info}`}>
                <h2 className={s.title}>{name}</h2>
                <p className={`flex ${s.description}`}>
                    {status == 'Approved' && 'Одобрено '} {formatDate(statusChangedWhen)}
                </p>
            </div>
        </li>
    );
};

export default RequestedBenefitCard;
