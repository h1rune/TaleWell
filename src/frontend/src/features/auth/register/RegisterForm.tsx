import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { register } from './RegisterForm.api';
import FormField from '../../../shared/ui/form_field/FormField'
import './registerForm.css'
import axios from 'axios';

function RegisterForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            await register({ email, password });
            alert('Регистрация прошла успешно, подтвердите свою почту.');
            navigate('/login');
        } catch (error) {
            if (axios.isAxiosError(error) && error.response) {
                const errorResponse = error.response;
                navigate(`/error?code=${errorResponse.status}&text=${errorResponse.statusText}`);
            } else {
                navigate(`/error?code=500&text=Серверная ошибка`);
            }
        }
    };

    return (
        <section className="registration">
            <h1>Создайте аккаунт</h1>
            <form onSubmit={handleSubmit}>
                <FormField type='email' placeholder='Введите почту' onChange={(event) => setEmail(event.target.value)} />
                <FormField type='password' placeholder='Введите пароль' onChange={(event) => setPassword(event.target.value)} />
                <FormField type='password' placeholder='Повторите пароль' onChange={(event) => setPassword(event.target.value)} />
                <button type="submit" className="registration-button">создать →</button>
            </form>
            <p className="login-link">
                <span>Уже есть аккаунт? </span>
                <a href="/login">Войдите</a>
            </p>
        </section>
    );
}

export default RegisterForm;