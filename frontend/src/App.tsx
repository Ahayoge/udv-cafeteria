import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './Normalize.css';
import './App.css';

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <header>
            <p>HELLO</p>
        </header>
    </StrictMode>
);
