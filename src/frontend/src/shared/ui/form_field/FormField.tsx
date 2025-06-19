import './formField.css'

interface FormFieldProps {
    type?: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    placeholder?: string;
}

function FormField({ type = 'text', onChange, placeholder }: FormFieldProps) {
    return <div className="form-field">
        <input type={type} onChange={onChange} placeholder={placeholder} required />
    </div>;
}

export default FormField;