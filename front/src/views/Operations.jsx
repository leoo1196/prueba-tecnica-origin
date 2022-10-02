import React from 'react';
import { Link } from "react-router-dom";
import BackToHomeButton from '../components/BackToHomeButton';

function Operations() {
    return (
        <div className="container">
            <div className="row pt-3">
                <div className="col-4"><Link className="btn btn-primary" style={{ width: '100%' }} to="/Balance">Balance</Link></div>
                <div className="col-4"><Link className="btn btn-primary" style={{ width: '100%' }} to="/Extraction">Retiro</Link></div>
                <div className="col-4"><BackToHomeButton className="btn btn-danger" style={{ width: '100%' }} text="Salir" /></div>
            </div>
        </div>
    );
}

export default Operations;