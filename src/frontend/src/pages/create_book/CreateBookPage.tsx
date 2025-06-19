import FormField from 'shared/ui/form_field/FormField';
import './createBookPage.css'
import NavigationPanel from 'widgets/navigation_panel/NavigationPanel';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createBook, Tag, TagsResponse } from './CreateBookPage.api';
import axios from 'axios';
import { useChannelStore } from 'entities/channel/store';
import { axiosInstance } from 'shared/api/axiosInstance';

function CreateBookPage() {
    document.title = `TaleWell – Создать книгу`
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [tags, setTags] = useState<Tag[]>([]);
    const [selectedTagIds, setSelectedTagIds] = useState<string[]>([]);
    const navigate = useNavigate();
    const ownChannel = useChannelStore((state) => state.channel);

    useEffect(() => {
    axiosInstance.get<TagsResponse>("/art/tags")
      .then(response => setTags(response.data.tags))
      .catch(error => console.error("Ошибка загрузки тегов:", error));
    }, []);

    const handleCheckboxChange = (tagId: string) => {
        setSelectedTagIds(prev =>
        prev.includes(tagId) ? prev.filter(id => id !== tagId) : [...prev, tagId]
        );
    };

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            const ownerHandle = ownChannel?.handle;
            if(ownerHandle != null)
            {
                await createBook({title, description, ownerHandle, selectedTagIds});
            }
            // navigate(`books/${}/edit`)
        } catch(error){
            if (axios.isAxiosError(error) && error.response) {
                const errorResponse = error.response;
                navigate(`/error?code=${errorResponse.status}&text=${errorResponse.statusText}`);
            } else {
                navigate(`/error?code=500&text=Серверная ошибка`);
            }
        }
    }
    return (
        <main className="page">
            <NavigationPanel /> 
            <div className="main-panel">
                <div className="settings-area">
                    <form onSubmit={handleSubmit} className="settings">
                        <FormField placeholder='Название произведения' onChange={(event) => setTitle(event.target.value)} />
                        <FormField placeholder='Описание произведения' onChange={(event) => setDescription(event.target.value)} />
                        <div>
                            <label className="block font-semibold mb-1">Выберите теги:</label>
                            <div className="flex flex-wrap gap-2">
                            {tags.map(tag => (
                                <label key={tag.id} className="flex items-center gap-1">
                                <input
                                    type="checkbox"
                                    checked={selectedTagIds.includes(tag.id)}
                                    onChange={() => handleCheckboxChange(tag.id)}
                                />
                                {tag.name}
                                </label>
                            ))}
                            </div>
                        </div>
                        <button type="submit" className="publish-button">создать</button>
                    </form>
                </div>
            </div>
        </main>
    );
}

export default CreateBookPage;
