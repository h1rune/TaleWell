import { Navigate, useParams } from 'react-router-dom';
import './channelPage.css'
import NavigationPanel from 'widgets/navigation_panel/NavigationPanel';

function ChannelPage() {
    const { handle } = useParams();
    if(handle == null){
        return <Navigate to="/channels/talewell" replace />;
    }

    document.title = handle;

    return (
        <main className="page">
            <NavigationPanel /> 
        </main>
    );
}

export default ChannelPage;
