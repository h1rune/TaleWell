import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createChannel } from './CreateChannel.api';
import FormField from '../../../shared/ui/form_field/FormField'
import './createChannelForm.css'
import axios from 'axios';

function CreateChannelForm() {
    const [title, setTitle] = useState('');
    const [handle, setHandle] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            await createChannel({title, handle});
            navigate(`/channels/${handle}`);
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
        <section className="create-channel">
            <h1>Создайте канал</h1>
            <form onSubmit={handleSubmit}>
                <FormField placeholder='Введите название канала' onChange={(event) => setTitle(event.target.value)} />
                <FormField placeholder='Придумайте уникальное имя' onChange={(event) => setHandle(event.target.value)} />
                <button type="submit">создать +</button>
            </form>
        </section>
    );
}

export default CreateChannelForm;