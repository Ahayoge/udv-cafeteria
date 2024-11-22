import s from './RequestsPage.module.css';
import RequestedBenefitCard from '../../Components/RequestedBenefitCard/RequestedBenefitCard';
import axios, { AxiosResponse } from 'axios';
import { useEffect, useState } from 'react';

type RequestsList = {
    id: string;
    name: string;
    status: string;
    statusChangedWhen: string;
};

const RequestsPage = () => {
    const [requestsList, setRequestsList] = useState<RequestsList[]>();
    const getRequestedBenefits = () => {
        let token = localStorage.getItem('authToken');
        axios
            .get('/benefitRequests', {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response: AxiosResponse) => {
                setRequestsList(response.data)
            })
            .catch(error => {
                console.log(error);
            });
    };

    useEffect(() => {
        getRequestedBenefits();
    }, []);
    return (
        <ul className={s.container}>
            {requestsList?.map((item)=> {
              return <RequestedBenefitCard data={item}></RequestedBenefitCard>
            })}
            
        </ul>
    );
};

export default RequestsPage;
