import { Navigate, Outlet } from 'react-router-dom';

const PrivateRoute = () => {
    const authToken = localStorage.getItem('authToken');
    return authToken ? <Outlet /> : <Navigate to="/auth" />;
};

export default PrivateRoute;