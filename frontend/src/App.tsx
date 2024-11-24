import './fonts/Fonts.css'
import './normalize.css';
import './App.css';
import AuthPage from './Pages/AuthPage/AuthPage';
import BenefitsPage from './Pages/BenefitsPage/BenefitsPage';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import SingleBenefitPage from './Pages/SingleBenefitPage/SingleBenefitPage';
import Header from './Components/Header/Header';
import PrivateRoute from './Components/PrivateRoute';
// import AddBenefitPage from './Pages/AddBenefitPage/AddBenefitPage';
import RequestsPage from './Pages/RequestsPage/RequestsPage';
import MyBenefitsPage from './Pages/MyBenefitsPage/MyBenefitsPage';
import Container from './Components/Container/Container';
import { ToastProvider } from './Store/ToastContext';
import axios from 'axios';

function App() {
    axios.defaults.baseURL = 'https://wizzasd.ru:7178/api/';
    
    return (
        <ToastProvider>
            <BrowserRouter>
                <Routes>
                    <Route element={<PrivateRoute />}>
                        <Route element={<Header />}>
                            <Route path='/' element={<Navigate to='/benefits/all' replace />} />
                            <Route element={<Container />}>
                                <Route path='/benefits'>
                                    <Route path='all' element={<BenefitsPage />} />
                                    <Route path='history' element={<BenefitsPage />} />
                                    <Route path='my' element={<MyBenefitsPage />} />
                                    {/* <Route path='new' element={<AddBenefitPage />} /> */}
                                    <Route path='requested' element={<RequestsPage />} />
                                    <Route path=':id' element={<SingleBenefitPage />} />
                                </Route>
                            </Route>
                        </Route>
                    </Route>
                    <Route path='/auth' element={<AuthPage />} />
                </Routes>
            </BrowserRouter>
        </ToastProvider>
    );
}

export default App;
