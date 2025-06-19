import { ChannelListItemProps } from 'shared/ui/channel_list_item/ChannelListItem';
import { axiosInstance } from 'shared/api/axiosInstance';

interface IChannelList {
    channels: ChannelListItemProps[]
}

export const getChannels = async () => {
    const result = await axiosInstance.get<IChannelList>('channel/subscriptions');
    return result.data.channels;
};