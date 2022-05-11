import React from 'react';
import axios from 'axios';

class AddCar extends React.Component {
    state = {
        person: {
            firstName: '',
            lastName: '',

        },
        car: {
            make: '',
            model: '',
            year: '',

        }

    }
    componentDidMount = async () => {
        const { id } = this.props.match.params;
        const { data } = await axios.get('/api/home/getperson?id=' + id);
        this.setState({ person: data });


    }
    onAddClick = async () => {
        const { make, model, year } = this.state.car;
        const { id } = this.props.match.params;
        await axios.post('/api/home/addcarforperson', { make, model, year, personId: id });
        this.props.history.push('/');
    }
    onTextChange = e => {
        const copy = { ...this.state.car };
        copy[e.target.name] = e.target.value;
        this.setState({ car: copy });
    }
    render() {
        const { firstName, lastName } = this.state.person;
        return (
            <div className="row">
                <div className="col-md-6 offset-md-3 card card-body bg-light">
                    <h1>Add a car for {firstName} {lastName}</h1>
                    <input type="text" name='make' onChange={this.onTextChange} className="form-control" placeholder="Make" />
                    <br />
                    <input type="text" name='model' onChange={this.onTextChange} className="form-control" placeholder="Model" />
                    <br />
                    <input type="text" name='year' onChange={this.onTextChange} className="form-control" placeholder="Year" />
                    <br />
                    <button onClick={this.onAddClick} className="btn btn-primary btn-block">Add</button>
                </div>
            </div>
        )
    }


}
export default AddCar;