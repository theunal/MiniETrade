

export interface FacebookLoginRequest {
    authToken: string
    email: string
    firstName: string
    id: string
    lastName: string
    name: string
    photoUrl: string
    provider: string
    response: {
        email: string
        first_name: string
        id: string
        last_name: string
        name: string
        picture: {
            data: {
                height: number
                is_silhouette: boolean
                url: string
                width: number
            }
        }
    }
}