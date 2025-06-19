import RegisterForm from 'features/auth/register/RegisterForm';
import grayLogo from '../../shared/images/gray_logo.svg';
import './registerPage.css'

function RegisterPage() {
    document.title = `TaleWell – Регистрация`
    return (
        <main className="page">
            <RegisterForm />
            <img className="logo" src={grayLogo} alt="logo" />
            <footer className="agreement-links">
                <p>
                    <span>Продолжая, вы подтверждаете, что ознакомлены с </span>
                    <a href="/terms">пользовательским соглашением</a>
                    <span> и даёте согласие на </span>
                    <a href="/privacy">обработку персональных данных.</a>
                </p>
            </footer>
        </main>
    );
}

export default RegisterPage;
