import s from './ProfileDropdown.module.css';
import axios, { AxiosResponse } from 'axios';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

type UserData = {
    firstName: string;
    patronymic: string;
    lastName: string;
    ucoins: number;
    experienceYears: number;
};

const ProfileDropdown = () => {
    const [userData, setUserData] = useState<UserData>();
    const { firstName, patronymic, lastName, ucoins, experienceYears } = userData || {};
    const navigate = useNavigate()
    const logOut = () => {
        localStorage.removeItem('authToken');
        navigate('/auth')
    };

    const getUserData = () => {
        let token = localStorage.getItem('authToken');
        axios
            .get('http://95.82.231.190:7178/api/employees/me', {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
            .then((response: AxiosResponse) => {
                setUserData(response.data);
            })
            .catch(error => {
                console.log(error);
            });
    };

    useEffect(() => {
        getUserData();
    }, []);
    return (
        <div className={`flex ${s.profile}`}>
            <div className={`flex ${s.profile_info}`}>
                <h2 className={s.name}>{`${lastName} ${firstName} ${patronymic}`}</h2>
                <p className={s.info}>
                    Баланс: <span className={s.bold}>{ucoins} u-coins</span>
                </p>
                <p className={s.info}>
                    Стаж: <span className={s.bold}>{experienceYears} лет</span>
                </p>
            </div>
            <button className={s.button} onClick={logOut}>Выйти</button>
        </div>
    );
};

export default ProfileDropdown;
