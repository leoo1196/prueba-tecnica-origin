import React from 'react';
import { useNavigate } from "react-router-dom";

function BackToHomeButton({ text, className, style }) {
    const navigate = useNavigate();

    const backToHome = () => {
        localStorage.setItem('cardNumber', undefined);
        localStorage.setItem('cardId', undefined);
        navigate('/');
    }

    return (
        <button className={className} style={style} onClick={backToHome}>{text}</button>
    );
}

export default BackToHomeButton;