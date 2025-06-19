import { axiosInstance } from 'shared/api/axiosInstance';

interface RegisterData {
    email: string;
    password: string;
}

export const register = async (data: RegisterData) => {
    await axiosInstance.post('auth/accounts/register', data);
};
