import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import './App.css';
import Balance from './views/Balance';
import Error from './views/Error';
import Extraction from './views/Extraction';
import Home from './views/Home';
import Operations from './views/Operations';
import Pin from './views/Pin';
import Report from './views/Report';

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route index element={<Home />} />
                <Route path="Pin" element={<Pin />} />
                <Route path="Balance" element={<Balance />} />
                <Route path="Extraction" element={<Extraction />} />
                <Route path="Operations" element={<Operations />} />
                <Route path="Report/:operationId" element={<Report />} />
                <Route path="*" element={<Error message="Pagina no encontrada" />} />
            </Routes>
        </BrowserRouter >
    );
}

export default App;
