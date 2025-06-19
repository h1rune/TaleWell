import CreateChannelForm from 'features/channel/create/CreateChannelForm';
import './createChannelPage.css'
import creativeLogo from 'shared/images/creative_logo.svg'

function CreateChannelPage() {
    document.title = `TaleWell – Создать новый канал`
    return (
        <main className="page">
            <CreateChannelForm />
            <img src={creativeLogo} alt="logo" />
        </main>
    );
}

export default CreateChannelPage;