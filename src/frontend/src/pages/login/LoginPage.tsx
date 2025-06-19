import LoginForm from 'features/auth/login/LoginForm';
import logo from '../../shared/images/logo.svg';
import './loginPage.css'

function LoginPage() {
    document.title = `TaleWell – Вход`
    return (
        <main className="page">
            <title>TaleWell – Вход</title>
            <img className="logo" src={logo} alt="logo" />
            <LoginForm />
        </main>
    );
}

export default LoginPage;
