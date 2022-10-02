import axios from 'axios';
import React, { useState } from 'react';
import { Link, useNavigate } from "react-router-dom";
import Keyboard from '../components/Keyboard';

function Pin() {
    const [pin, setPin] = useState('');
    const [badInputMessage, setBadInputMessage] = useState('');
    const navigate = useNavigate();

    const addDigit = (digit) => {
        if (pin.length < 4) {
            setPin(pin + digit);
        }
    };

    const validatePin = () => {
        const cardNumber = localStorage.getItem('cardNumber');
        const request = {
            cardNumber, pin
        };

        axios.post('https://localhost:7286/Atm/validate-pin', request).then(response => {
            const { cardId } = response.data;
            localStorage.setItem('cardId', cardId);
            navigate('/Operations');
        }, error => {
            const { message: errorMessage } = error.response.data;

            if (error.response.status === 400) {
                setBadInputMessage(errorMessage);
            }
            else {
                navigate(`/Error?error=${errorMessage}`);
            }
        });
    };

    return (
        <div className="container">
            <h2 className="text-center">Ingrese el PIN</h2>

            <input type="text" className="form-control" disabled value={pin} />

            <Keyboard setter={addDigit} />

            {
                badInputMessage &&
                <div className="row pt-3" >
                    <h4 className="text-center" style={{ color: 'red' }}>{badInputMessage}</h4>
                </div>
            }

            <div className="row">
                <div className="col-4"><button className="btn btn-primary" style={{ width: '100%' }} onClick={validatePin}>Aceptar</button></div>
                <div className="col-4"><button className="btn btn-danger" style={{ width: '100%' }} onClick={() => setPin('')}>Limpiar</button></div>
                <div className="col-4"><Link to="/" className="btn btn-danger" style={{ width: '100%' }}>Salir</Link></div>
            </div>
        </div>
    );
}

export default Pin;