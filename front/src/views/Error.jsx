import React from 'react';
import { useSearchParams } from "react-router-dom";
import BackToHomeButton from '../components/BackToHomeButton';

function Error({ message }) {
    const [search] = useSearchParams();
    const errorMessage = search.get('error');

    return (
        <>
            <h2>Error</h2>
            <h3>{errorMessage ?? message}</h3>

            <BackToHomeButton className="btn btn-info" text="Atras" />
        </>
    );
}

export default Error;