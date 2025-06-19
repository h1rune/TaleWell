import { Channel } from 'entities/channel/channel';
import { axiosInstance } from 'shared/api/axiosInstance';

interface LoginData {
    email: string;
    password: string;
}

export const login = async (data: LoginData) => {
    await axiosInstance.post('auth/sessions/login', data);
};

export const getOwnChannel = async () => {
    const result = await axiosInstance.get<Channel>('channel/info');
    return result.data
};
