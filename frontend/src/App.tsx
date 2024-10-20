import { Routes, Route } from 'react-router-dom';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import LoginPage from './pages/Login/LoginPage';
import RegisterPage from './pages/Register/RegisterPage';

import './Normalize.css';
import './App.css';

const App = () => {
    const navigate = useNavigate();
    useEffect(() => {
        navigate('/login')
    }, []);
    return (
        <>
            <Routes>
                <Route element={<RegisterPage />} path='/register' />
                <Route element={<LoginPage />} path='/login' />
            </Routes>
        </>
    );
};

export default App;
