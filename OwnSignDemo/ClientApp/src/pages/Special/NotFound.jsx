
import { useNavigate } from 'react-router-dom'

export const NotFound = () => {
    const navigate = useNavigate();
    return (
        <p>404</p>
    );
}

export default NotFound;