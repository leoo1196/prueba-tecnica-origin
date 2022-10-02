import axios from 'axios';
import React, { useState } from 'react';
import InputMask from 'react-input-mask';
import { useNavigate } from "react-router-dom";
import Keyboard from '../components/Keyboard';

function Home() {
    const [cardNumber, setCardNumber] = useState('');
    const navigate = useNavigate();

    const addDigit = (digit) => {
        if (cardNumber.length < 16) {
            setCardNumber(cardNumber + digit);
        }
    }

    const validateCardNumber = () => {
        const request = {
            cardNumber
        };

        axios.post('https://localhost:7286/Atm/validate-card', request).then(() => {
            localStorage.setItem('cardNumber', cardNumber);
            navigate('/Pin');
        }, error => {
            const { message: errorMessage } = error.response.data;
            navigate(`/Error?error=${errorMessage}`);
        });
    };

    return (
        <div className="container">
            <h2 className="text-center">Ingrese el Numero de la tarjeta</h2>
            <h4>El numero de la tarjeta consta de 16 digitos</h4>

            <InputMask mask="9999-9999-9999-9999" className="form-control" value={cardNumber} disabled />

            <Keyboard setter={addDigit} />

            <div className="row">
                <div className="col-6"><button className="btn btn-primary" style={{ width: '100%' }} onClick={validateCardNumber}>Aceptar</button></div>
                <div className="col-6"><button className="btn btn-danger" style={{ width: '100%' }} onClick={() => setCardNumber('')}>Limpiar</button></div>
            </div>
        </div>
    );
}

export default Home;