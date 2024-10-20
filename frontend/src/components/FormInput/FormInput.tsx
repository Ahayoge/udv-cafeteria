import s from './Forminput.module.css';
import { MouseEvent, useState } from 'react';
import clsx from 'clsx';

interface Props {
    type?: string;
    id: string;
    placeholder?: string;
    pattern?: string;
    children: React.ReactNode;
}

const FormInput = (Props: Props) => {
    const { type, id, placeholder, pattern, children } = Props;
    return (
        <label className={`flex ${s.label}`}>
            {children}
            <input
                className={s.input}
                id={id}
                type={type}
                placeholder={placeholder}
                pattern={pattern}
                autoComplete='on'
            />
        </label>
    );
};

const PasswordInput = (Props: Props) => {
    const { id, children } = Props;
    const [isVisible, setVisible] = useState<boolean>(false);
    const handlePasswordVisibility = (
        e: MouseEvent<HTMLButtonElement, globalThis.MouseEvent>
    ) => {
        e.preventDefault();
        setVisible(!isVisible);
    };
    return (
        <label className={`flex ${s.label}`}>
            {children}
            <input
                className={s.input}
                id={id}
                type={isVisible ? 'text' : 'password'}
                autoComplete='on'
            />
            <button
                className={clsx(s.password_button, isVisible && s.visible)}
                onClick={e => {
                    handlePasswordVisibility(e);
                }}
            />
        </label>
    );
};

export { FormInput, PasswordInput };
