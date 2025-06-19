import { useLocation } from 'react-router-dom';
import errorLogo from '../../shared/images/error_logo.svg';
import './errorPage.css'

function ErrorPage() {
    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const errorCode = searchParams.get('code'); 
    const errorText = searchParams.get('text');
    document.title = `TaleWell – ${ errorText }`
    return (
        <main className="page">
            <img src={errorLogo} alt="logo" />
            <div className="error-info-block">
                <div className="error-info">
                    <h1 className="error-code">{ errorCode }</h1>
                    <p className="error-text">{ errorText }</p>
                </div>
                <a className="back-link" href="/">← на главную</a>
            </div>
        </main>
    );
}

export default ErrorPage;
