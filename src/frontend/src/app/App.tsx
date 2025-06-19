import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ErrorPage from '../pages/error/ErrorPage';
import './styles/theme.css';
import './styles/index.css';
import RegisterPage from 'pages/register/RegisterPage';
import LoginPage from 'pages/login/LoginPage';
import ChannelPage from 'pages/channel/ChannelPage';
import CreateChannelPage from 'pages/create_channel/CreateChannelPage';
import { ProtectedRoute } from 'shared/lib/ProtectedRoute';
import MainPage from 'pages/main/MainPage';
import CreateBookPage from 'pages/create_book/CreateBookPage';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/error" element={ <ErrorPage /> } />
        <Route path='/register' element={ <RegisterPage /> } />
        <Route path='/login' element={ <LoginPage /> } />
        <Route path='/' element={ <ProtectedRoute><MainPage /></ProtectedRoute> } />
        <Route path='/create-channel' element={ <ProtectedRoute><CreateChannelPage /></ProtectedRoute> } />
        <Route path='/channels/:handle' element={ <ProtectedRoute><ChannelPage /></ProtectedRoute> } />
        <Route path='/create-book' element={ <ProtectedRoute><CreateBookPage /></ProtectedRoute> } />
      </Routes>
    </Router>
  );
}

export default App;