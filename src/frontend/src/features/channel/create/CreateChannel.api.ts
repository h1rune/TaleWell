import { axiosInstance } from "shared/api/axiosInstance";

interface ChannelData {
    title: string;
    handle: string;
    description?: string;
}

export const createChannel = async (data: ChannelData) => {
    await axiosInstance.post('channel/info', data);
};
