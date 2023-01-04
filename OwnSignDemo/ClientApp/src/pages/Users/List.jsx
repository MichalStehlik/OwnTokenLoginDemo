import {useState, useEffect} from "react"
import { Link } from "react-router-dom"
import { useAuthContext} from "../../providers/AuthProvider"
import axios from "axios"

export const List = () => {
    const [{accessToken}] = useAuthContext();
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);
    const [data, setData] = useState(null);
    useEffect(()=>{
        setLoading(true);
        setError(false);
        axios.get("/api/users", {headers: { Authorization: "Bearer " + accessToken, "Content-Type": "application/json" }})
        .then(response => {
            setData(response.data);
        })
        .catch(error => {
            setError(error.message);
            console.error(error);
        })
        .then(()=>{
            setLoading(false);
        })
    },[accessToken]);
    return (
        <>
            <Link to="create">Create</Link>
            <Link to="generate">Generate</Link>
            <h1>List</h1>
            { loading 
            ? 
            <p>Loading</p> 
            :
                error
                ?
                <p>{error}</p>
                :
                    data
                    ?
                    <table>
                        {data.map((item, index) => (
                            <tr key={index}>
                                <td>{item.userId}</td>
                                <td>{item.username}</td>
                                <td>{item.password}</td>
                            </tr>
                        ))}
                    </table>
                    :
                    <p>Not ready yet.</p>
            }
        </>
        
    );
}

export default List;