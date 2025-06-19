import IconHolder from 'shared/ui/icon_holder/IconHolder';
import './channelListItem.css'

export interface PostPreview {
    text: string
    time: string
}

export interface ChannelListItemProps {
    title: string;
    handle: string;
    tariffPlan: number;
    lastPost?: PostPreview;
    // iconLink?: string;
}

function ChannelListItem({ title, handle, lastPost }: ChannelListItemProps) {
    return (
        <a className="channel-nav-link" href={`/channels/${handle}`}>
            {
                // iconLink ?
                // <img className="nav-channel-icon" src={ iconLink } alt='channel icon' /> :
                <IconHolder letter={ title[0] }/>
            }
            <div className="nav-channel-info">
                <div className="nav-channel-header">
                    <p className="nav-channel-title">{ title }</p>
                    <p className="nav-channel-last-time">{ lastPost?.time }</p>
                </div>
                <div className="nav-channel-last-post">
                    <p className="last-post-text">{ lastPost?.text }</p>
                </div>
            </div>
        </a>
    );
}

export default ChannelListItem;