import React from 'react';
import './controlPanel.css'
import addIcon from 'shared/images/AddButton.svg'
import settingsIcon from 'shared/images/SettingsButton.svg'
import IconHolder from 'shared/ui/icon_holder/IconHolder';
import { useChannelStore } from 'entities/channel/store';
import { Navigate } from 'react-router-dom';

export const ControlPanel: React.FC = () => {
    const ownChannel = useChannelStore((state) => state.channel);

    if (ownChannel == null) {
        return <Navigate to="/login" replace />;
    }
    
    return (
        <div className="control-panel">
            {
                ownChannel == null ?
                <a href='/login'>Войдите</a> :
                <div className="own-channel-link">
                    {
                        // data.iconLink ? 
                        // <img className="own-channel-icon" src={data.iconLink} alt='own channel icon' /> :
                        <IconHolder letter={ownChannel?.title[0]} />
                    }
                    <div className="own-channel-info">
                        <a className="own-channel-title">{ownChannel.title}</a>
                        <a href={`/channels/${ownChannel.handle}`} className="own-channel-id">@{ownChannel.handle}</a>
                    </div>
                </div>
            }
            <a href='/create-book'><img className="add-button" src={addIcon} alt='add icon' /></a>
            <a href='/settings'><img className="settings-button" src={settingsIcon} alt='settings icon' /></a>
        </div>
    );
};
