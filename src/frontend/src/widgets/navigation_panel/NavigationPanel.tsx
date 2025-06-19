import { SubscriptionList } from 'features/navigation_panel/channel_list/ChannelList';
import logo from 'shared/images/logo.svg'
import searchIcon from 'shared/images/search-icon.svg'
import bookmarkIcon from 'shared/images/bookmark-button.svg'
import './navigationPanel.css'
import { ControlPanel } from 'features/navigation_panel/control_panel/ControlPanel';


function NavigationPanel() {
    return (
        <div className="navigation-panel">
            <div className="header">
                <a className="header-logo" href='/'>
                    <img className="header-logo" src={logo} alt='logo' />
                    <p className="header-logo-text">TaleWell</p>
                </a>
                <a className="search-button" href=''>
                    <img className="search-icon" src={searchIcon} alt='search icon' />
                </a>
                <a href=''>
                    <img className="bookmark-button" src={bookmarkIcon} alt='bookmark icon' />
                </a>
            </div>
            
            <SubscriptionList />
            <ControlPanel />
        </div>
    );
}

export default NavigationPanel;
