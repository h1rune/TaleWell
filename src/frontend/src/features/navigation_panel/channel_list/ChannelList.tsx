import React from 'react';
import { useChannels } from './UseChannels';
import ChannelListItem, { ChannelListItemProps } from 'shared/ui/channel_list_item/ChannelListItem';
import './channelList.css'

export const SubscriptionList: React.FC = () => {
    const { data, loading, error } = useChannels();
    
    return (
        <div className="subscribed-channels-list">
            <div className="subscribed-channels">
                {
                    loading ?
                    <p>Загрузка...</p> :
                    (error ?
                    <p>Ошибка: {error}</p> :
                    (!data || data.length == 0 ?
                    <p>Нет подписок</p> :
                    data.map((channel: ChannelListItemProps) => (
                            <ChannelListItem 
                                title={ channel.title } 
                                handle={ channel.handle } 
                                lastPost={ channel.lastPost } 
                                tariffPlan={ channel.tariffPlan }
                                // iconLink={ channel.iconLink } 
                            />
                        )
                    )))
                }
            </div>
        </div>
    );
};
