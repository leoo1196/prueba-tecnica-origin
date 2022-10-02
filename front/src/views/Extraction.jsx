import axios from 'axios';
import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";
import BackToHomeButton from '../components/BackToHomeButton';
import Keyboard from '../components/Keyboard';

function Extraction() {
    const [amount, setAmount] = useState('');
    const navigate = useNavigate();

    const addDigit = (digit) => {
        if (amount.length < 10) {
            setAmount(amount + digit);
        }
    };

    const processExtraction = () => {
        const cardId = localStorage.getItem('cardId');

        axios.post('https://localhost:7286/Atm/extraction', { cardId, amount }).then(response => {
            const { operationId } = response.data;
            navigate(`/Report/${operationId}`);
        }, error => {
            const { message: errorMessage } = error.response.data;
            navigate(`/Error?error=${errorMessage}`);
        });
    };

    return (
        <div className="container">
            <h2 className="text-center">Ingrese un monto</h2>

            <input type="text" className="form-control" disabled value={amount} />

            <Keyboard setter={addDigit} />

            <div className="row">
                <div className="col-4"><button className="btn btn-danger" style={{ width: '100%' }} onClick={() => setAmount('')}>Limpiar</button></div>
                <div className="col-4"><button className="btn btn-primary" style={{ width: '100%' }} onClick={processExtraction}>Aceptar</button></div>
                <div className="col-4"><BackToHomeButton className="btn btn-danger" style={{ width: '100%' }} text="Salir" /></div>
            </div>
        </div>
    );
}

export default Extraction;