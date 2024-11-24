import React, { createContext, useContext } from 'react';
import { toast, ToastContainer, ToastOptions } from 'react-toastify';

type NotifyType = 'success' | 'error' | 'info' | 'warn';

type ToastContextType = {
    notify: (message: string, type?: NotifyType, options?: ToastOptions) => void;
};

const ToastContext = createContext<ToastContextType | undefined>(undefined);

export const ToastProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const notify = (message: string, type: NotifyType = 'info', options?: ToastOptions) => {
        switch (type) {
            case 'success':
                toast.success(message, options);
                break;
            case 'error':
                toast.error(message, options);
                break;
            case 'warn':
                toast.warn(message, options);
                break;
            case 'info':
            default:
                toast.info(message, options);
                break;
        }
    };

    return (
        <ToastContext.Provider value={{ notify }}>
            {children}
            <ToastContainer />
        </ToastContext.Provider>
    );
};

export const useToast = () => {
    const context = useContext(ToastContext);
    if (!context) {
        throw new Error('useToast must be used within a ToastProvider');
    }
    return context;
};