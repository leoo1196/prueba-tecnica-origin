import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link, useParams, useNavigate } from "react-router-dom";
import BackToHomeButton from '../components/BackToHomeButton';

function Report() {
    const [operation, setOperation] = useState({});
    const navigate = useNavigate();
    const params = useParams();

    const getOperation = () => {
        axios.get(`https://localhost:7286/Atm/operation/${params.operationId}`).then(response => {
            setOperation(response.data);
        }, error => {
            const { message: errorMessage } = error.response.data;
            navigate(`/Error?error=${errorMessage}`);
        });
    };

    useEffect(() => getOperation, []);

    return (
        <div className="container">
            <h2>Datos de la operacion</h2>

            <div className="row">
                <div className="form-group col-6">
                    <label>Numero</label>
                    <input className="form-control" disabled value={operation.cardNumber} />
                </div>

                <div className="form-group col-6">
                    <label>Fecha y hora</label>
                    <input className="form-control" disabled value={operation.operationTime} />
                </div>
            </div>

            <div className="row">
                <div className="form-group col-6">
                    <label>Cantidad retirada</label>
                    <input className="form-control" disabled value={operation.extractionAmount} />
                </div>

                <div className="form-group col-6">
                    <label>Balance actual</label>
                    <input className="form-control" disabled value={operation.balance} />
                </div>
            </div>

            <div className="row pt-3">
                <div className="col-4"><Link className="btn btn-primary" style={{ width: '100%' }} to="/Operations">Atras</Link></div>
                <div className="col-4"><BackToHomeButton className="btn btn-danger" style={{ width: '100%' }} text="Salir" /></div>
            </div>
        </div>
    );
}

export default Report;