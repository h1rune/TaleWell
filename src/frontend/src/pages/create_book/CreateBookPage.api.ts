import { axiosInstance } from 'shared/api/axiosInstance';

export interface Tag {
  id: string;
  name: string;
}

export interface TagsResponse{
    tags: Tag[];
}

interface CreateBookData {
    title: string;
    description: string;
    ownerHandle: string;
    selectedTagIds: string[];
}

export const createBook = async (data: CreateBookData) => {
    await axiosInstance.post('art/works/', data);
};