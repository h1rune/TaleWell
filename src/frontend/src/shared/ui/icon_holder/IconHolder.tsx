import './iconHolder.css'

interface IconHolderProps {
    letter: string;
}

function IconHolder({ letter }: IconHolderProps) {
    return <div className="icon-holder">
        <a>{ letter }</a>
    </div>;
}

export default IconHolder;
