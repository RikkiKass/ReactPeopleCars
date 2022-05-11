import React from 'react';
import axios from 'axios';
import CarRow from './CarRow'
class DeleteCars extends React.Component {
    state = {
        cars: []
    }
    componentDidMount = async () => {
        const { id } = this.props.match.params;
        const { data } = await axios.get(`/api/home/getcars?id=${id}`);
        console.log(data);
        this.setState({ cars: data });

    }
    onNoClick = () => {
        this.props.history.push('/');
    }
    onYesClick = async () => {
        await axios.post('/api/home/deletecars', this.state.cars);
        this.props.history.push('/');
    }
    render() {
        const { cars } = this.state;
        return (
            <div className="row">
                <table className="table table-bordered table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Make</th>
                            <th>Model</th>
                            <th>Year</th>
                        </tr>
                    </thead>
                    <tbody>
                        {cars.map(c => <CarRow
                            car={c}
                        />)}
                    </tbody>
                </table>
                <h1>Are you sure you want to delete all of these cars?</h1>
                <div className='row'>
                    <button className='btn btn-lg btn-block btn-primary' onClick={this.onNoClick}>No</button>
                    <button className='btn btn-lg btn-block btn-danger' onClick={this.onYesClick}>Yes</button>
                </div>
            </div>

        )

    }
}
export default DeleteCars;