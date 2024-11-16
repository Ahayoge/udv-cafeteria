import './App.css';
import AuthPage from './Pages/AuthPage/AuthPage';
import BenefitsPage from './Pages/BenefitsPage/BenefitsPage';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import SingleBenefitPage from './Pages/SingleBenefitPage/SingleBenefitPage';
import Header from './Components/Header/Header';
import PrivateRoute from './Components/PrivateRoute';
import AddBenefitPage from './Pages/AddBenefitPage/AddBenefitPage';
import RequestsPage from './Pages/RequestsPage/RequestsPage'
import MyBenefitsPage from './Pages/MyBenefitsPage/MyBenefitsPage';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                {/* Приватные маршруты */}
                <Route element={<PrivateRoute />}>
                    {/* Вложенные маршруты с Header */}
                    <Route element={<Header />}>
                        {/* Перенаправление с "/" на "/benefits/all" */}
                        <Route path="/" element={<Navigate to="/benefits/all" replace />} />
                        {/* Основные маршруты для benefits */}
                        <Route path="/benefits">
                            <Route path="all" element={<BenefitsPage />} />
                            <Route path="history" element={<BenefitsPage />} />
                            <Route path="my" element={<MyBenefitsPage />} />
                            <Route path="new" element={<AddBenefitPage />} />
                            <Route path="requested" element={<RequestsPage />} />
                            <Route path=":id" element={<SingleBenefitPage />} />
                        </Route>
                    </Route>
                </Route>

                {/* Публичный маршрут для аутентификации */}
                <Route path="/auth" element={<AuthPage />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
