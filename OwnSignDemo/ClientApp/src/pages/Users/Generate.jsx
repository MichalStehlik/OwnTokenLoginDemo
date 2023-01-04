import {requireAuth} from "../../hocs/requireAuth"

export const Generate = () => {
    return (
        <p>Generate</p>
    );
}

export default requireAuth(Generate);