import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { getOwnChannel, login } from './LoginForm.api';
import FormField from '../../../shared/ui/form_field/FormField'
import './loginForm.css'
import axios from 'axios';
import { useChannelStore } from 'entities/channel/store';

function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            await login({ email, password });
            try {
                const ownChannel = await getOwnChannel();
                useChannelStore.getState().setChannel(ownChannel);
                navigate(`/channels/${ownChannel.handle}`);
            } catch (error) {
                navigate('/create-channel')
            }
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
        <section className="login">
            <h1>Войдите в аккаунт</h1>
            <form onSubmit={handleSubmit}>
                <FormField type='email' placeholder='Введите почту' onChange={(event) => setEmail(event.target.value)} />
                <FormField type='password' placeholder='Введите пароль' onChange={(event) => setPassword(event.target.value)} />
                <a className='password-forget-link'>Забыли пароль?</a>
                <button type="submit">войти →</button>
            </form>
            <p className="login-link">
                <span>Нет аккаунта? </span>
                <a href="/register">Зарегистрируйтесь</a>
            </p>
        </section>
    );
}

export default LoginForm;
