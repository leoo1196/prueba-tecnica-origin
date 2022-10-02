import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from "react-router-dom";
import BackToHomeButton from '../components/BackToHomeButton';

function Balance() {
    const [card, setCard] = useState({});
    const navigate = useNavigate();

    const getBalance = () => {
        const cardId = localStorage.getItem('cardId');

        axios.post('https://localhost:7286/Atm/balance', { cardId }).then(response => {
            setCard(response.data);
        }, error => {
            const { message: errorMessage } = error.response.data;
            navigate(`/Error?error=${errorMessage}`);
        });
    };

    useEffect(() => getBalance, []);

    return (
        <div className="container">
            <h2>Datos de la tarjeta</h2>

            <div className="row">
                <div className="form-group col-6">
                    <label>Numero</label>
                    <input className="form-control" disabled value={card.cardNumber} />
                </div>

                <div className="form-group col-6">
                    <label>Fecha de vencimiento</label>
                    <input className="form-control" disabled value={card.dueDate} />
                </div>
            </div>

            <div className="row">
                <div className="form-group col-6">
                    <label>Balance</label>
                    <input className="form-control" disabled value={card.balance} />
                </div>
            </div>

            <div className="row pt-3">
                <div className="col-4"><Link className="btn btn-primary" style={{ width: '100%' }} to="/Operations">Atras</Link></div>
                <div className="col-4"><BackToHomeButton className="btn btn-danger" style={{ width: '100%' }} text="Salir" /></div>
            </div>
        </div>
    );
}

export default Balance;